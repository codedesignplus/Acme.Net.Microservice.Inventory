export VAULT_ADDR="http://0.0.0.0:8200"

vault login token=root

# Enable Secret, database and rabbtimq
# archetype = solution name (software)

# Enable AppRole
echo "1. Enabling auth methods..."
vault auth enable approle

# Enable Secret, database and rabbtimq
echo "2. Enabling secrets engines..."
vault secrets enable -path=e-comerce-acme-keyvalue kv-v2
vault secrets enable -path=e-comerce-acme-database database
vault secrets enable -path=e-comerce-acme-rabbitmq rabbitmq
vault secrets enable -path=e-comerce-acme-transit transit

# Create policies
echo "3. Applying policies..."
vault policy write full-access /resources/full-access.hcl

# Create roles
echo "4. Creating roles..."
vault write auth/approle/role/e-comerce-acme-approle policies="full-access"

role_id=$(vault read auth/approle/role/e-comerce-acme-approle/role-id | grep 'role_id' | awk '{print $2}')

secret_id=$(vault write -f auth/approle/role/e-comerce-acme-approle/secret-id | grep 'secret_id ' | awk '{print $2}')

if [ -z "$role_id" ] || [ -z "$secret_id" ]; then
    echo "Error: Not found role_id or secret_id"
    exit 1
fi

file="credentials.json"

cat <<EOF > /vault/config/$file
{
  "role_id": "$role_id",
  "secret_id": "$secret_id"
}
EOF

echo "Role ID: $role_id"
echo "Secret ID: $secret_id"

# Login with approle
echo "5. Login with approle..."
vault write auth/approle/login role_id=$role_id secret_id=$secret_id

# Write secrets
echo "6. Writing secrets..."
vault kv put -mount=e-comerce-acme-keyvalue ms-inventory \
    Security:ClientId=a74cb192-598c-4757-95ae-b315793bbbca \
    Security:ValidAudiences:0=a74cb192-598c-4757-95ae-b315793bbbca \
    Security:ValidAudiences:1=api://a74cb192-598c-4757-95ae-b315793bbbca \
    Redis:Instances:Core:ConnectionString=localhost:6379
    
vault kv get -mount=e-comerce-acme-keyvalue ms-inventory

# Write database configuration
echo "7. Writing database configuration..."
vault write e-comerce-acme-database/config/db-ms-inventory \
    plugin_name=mongodb-database-plugin \
    allowed_roles="ms-inventory-mongo-role" \
    connection_url="mongodb://{{username}}:{{password}}@mongo:27017/admin?ssl=false" \
    username="admin" \
    password="password"

vault write e-comerce-acme-database/roles/ms-inventory-mongo-role \
    db_name=db-ms-inventory \
    creation_statements='{ "db": "admin", "roles": [{ "role": "readWrite", "db": "db-ms-inventory" }] }' \
    default_ttl="1h" \
    max_ttl="24h"

vault read e-comerce-acme-database/creds/ms-inventory-mongo-role

# Write rabbitmq configuration
echo "8. Writing rabbitmq configuration..."

sleep 15

vault write e-comerce-acme-rabbitmq/config/connection \
    connection_uri="http://rabbitmq:15672" \
    username="admin" \
    password="password"

vault write e-comerce-acme-rabbitmq/roles/ms-e-comerce-acme-rabbitmq-role \
    vhosts='{"/":{"write": ".*", "read": ".*", "configure": ".*"}}'

vault read e-comerce-acme-rabbitmq/creds/ms-e-comerce-acme-rabbitmq-role