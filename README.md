# CatPersonal - README corto

**NOTA TEMPORAL:** `appsettings.json` contiene actualmente la cadena de conexión con host y contraseña (esto es inseguro). Solo debe usarse por unos minutos para pruebas. Después de usarla, elimina la contraseña de `appsettings.json` o reemplázala por un placeholder y usa un `.env` o Secrets Manager.

Cómo limpiar rápidamente después de probar:

```bash
# 1) Abrir y editar appsettings.json: reemplazar Password=... por Password=YOUR_PASSWORD
# 2) O restaurar el placeholder:
sed -i '' "s/Password=ciberinfraestructura/Password=YOUR_PASSWORD/" appsettings.json
```

Proyecto: API REST mínima para la entidad CatPersonal (id, nombre, cargo).

Endpoints (únicos soportados)
- GET /api/CatPersonal
- GET /api/CatPersonal/{id}
- POST /api/CatPersonal

Levantar con Docker (rápido)
1. Crea un `.env` en el mismo directorio con la variable (no lo subas):

```env
CONNECTIONSTRING_DEFAULT=Host=ciberinfraestructura.c4faq866wiia.us-east-1.rds.amazonaws.com;Port=5432;Database=catpersonal_db;Username=postgres;Password=TU_PASSWORD
```

2. Construir y levantar (en background):

```bash
docker compose build
docker compose up -d web
```

3. Comprobar que responde:

```bash
curl -sS http://localhost:5001/api/CatPersonal
```

Pruebas rápidas (ejemplos)

```bash
# GET todos
curl -sS http://localhost:5001/api/CatPersonal

# POST (crear)
curl -sS -X POST http://localhost:5001/api/CatPersonal -H "Content-Type: application/json" -d '{"nombre":"Juan","cargo":"Dev"}'

# GET por id
curl -sS http://localhost:5001/api/CatPersonal/1
```

Notas rápidas
- No subas el `.env` ni archivos con credenciales.
- Si vas a producción, usa AWS Secrets Manager o Parameter Store.

¿Quieres que deje también comandos para crear migraciones EF o un workflow de GitHub Actions? (lo puedo agregar).

