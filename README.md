# NoteWebAPI

NoteWebAPI — это веб-API для управления заметками с аутентификацией пользователей через JWT. Проект реализован на .NET 8.0 с использованием MS SQL Server и Entity Framework. Поддерживает Docker-развертывание.

## 📌 Возможности

- Создание, чтение, обновление и удаление заметок
- Регистрация и аутентификация пользователей
- Защита эндпоинтов с помощью JWT
- Готовые Docker-образы для быстрого развертывания

## 🚀 Эндпоинты API

### 📝 Заметки

- `GET /api/note` — получить все заметки
- `GET /api/note/{noteId}` — получить заметку по ID
- `POST /api/note/{noteId}` — создать новую заметку
  ```json
  {
      "title": "My third note!",
      "text": "Third note)"
  }
  ```
- `PUT /api/note/{noteId}` — обновить существующую заметку
  ```json
  {
      "Title": "New title",
      "Text": "net text"
  }
  ```
- `DELETE /api/note/{noteId}` — удалить заметку

### 🔐 Аутентификация

- `POST /api/auth/register` — регистрация нового пользователя
  ```json
  {
      "username": "LazureBro",
      "email": "tom@gmail.com",
      "password": "1234"
  }
  ```
- `POST /api/auth/login` — вход в систему (возвращает JWT токен)
  ```json
  {
      "username": "LazureBro",
      "password": "1234"
  }
  ```

## 🛠 Технологии

- .NET 8.0
- MS SQL Server
- Entity Framework Core
- JWT Bearer Authentication
- Docker

## ⚙️ Настройка

### Конфигурация через appsettings.json

В `appsettings.json` есть следующие настройки:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=noteapi_db;Database=NoteApiDb;User Id=sa;Password=PLACEHOLDER;Trusted_Connection=False;TrustServerCertificate=True;"
  },
  "AuthSettings": {
    "Issuer": "Issuer",
    "Audience": "Audience",
    "Expires": "00:02:00",
    "SecretKey": "PLACEHOLDER_PLACEHOLDER"
  },
}
```

### Конфигурация через .env (для Docker)

Создайте файл `.env` со следующим содержимым:

```
# .env
DB_PASSWORD=db_password
JWT_SECRET_KEY=16_length_symbol_security_key
```

## 🐳 Запуск через Docker

1. Соберите образ:
   ```bash
   docker build -t noteapi .
   ```

2. Запустите приложение с помощью docker-compose:
   ```bash
   docker-compose up
   ```
