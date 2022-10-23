# book_library


<br>

## 📄 API Specs

### Book 

| HTTP Method | Use                            | Endpoint                |
| ----------- | ------------------------------ | ----------------------- |
| **GET**     | Info about all book            | `/api/Book`             |
| **GET**     | Show book by id                | `/api/Book/{id}`        |
| **GET**     | Top 5 authors                  | `/api/Book/top/authors` |
| **GET**     | Top 5 genres                   | `/api/Book/top/genres`  |
| **POST**    | Create new book                | `/api/Book`             |
| **PUT**     | Update book info               | `/api/Book/{id}`        |
| **DELETE**  | Delete book                    | `/api/books/{id}`       |

### User
| HTTP Method | Use                            | Endpoint                |
| ----------- | ------------------------------ | ----------------------- |
| **POST**    | Register user and get Bearer token for authorization           | `register`             |

<br>
