# CatPersonal - README corto

**NOTA TEMPORAL:** `appsettings.json` contiene actualmente la cadena de conexión con host y contraseña (esto es inseguro). Solo debe usarse por unos minutos para pruebas. Después de usarla, elimina la contraseña de `appsettings.json` o reemplázala por un placeholder y usa un `.env` o Secrets Manager.


Proyecto: API REST mínima para la entidad CatPersonal (id, nombre, cargo).

Endpoints (únicos soportados)
- GET /api/CatPersonal
- GET /api/CatPersonal/{id}
- POST /api/CatPersonal

Construir y levantar (en background):

```bash
docker compose build
docker compose up -d web
```

Comprobar que responde:

```bash
curl -sS http://localhost:5001/api/CatPersonal
```

EJEMPLOS

```bash
# GET todos
curl -sS http://localhost:5001/api/CatPersonal

# POST (crear)
curl -sS -X POST http://localhost:5001/api/CatPersonal -H "Content-Type: application/json" -d '{"nombre":"Juan","cargo":"Dev"}'

# GET por id
curl -sS http://localhost:5001/api/CatPersonal/1
```

