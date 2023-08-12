# Buber Dinner API

- [Buber Dinner API](#buber-dinner-api)
	- [Auth](#auth)
		- [Register](#register)
			- [Register Request](#register-request)
			- [Register Response](#register-response)
		- [Login](#login)
			- [Login Request](#login-request)
			- [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
	"firstName": "Kenan",
	"lastName": "Asaad",
	"email": "kenan@asaad.com"
	"password": "kenanAsaad123"

}
```

#### Register Response
```js
200 OK
```

```json
{
	"id": "d1312eca-5979-41a1-bfb6-347bb426761b",
	"firstName: "kenan",
	"lastName: "asaad",
	"email": "kenan@asaad.com",
	"token": "eyJhb..z9dqcnXoY"
}
```

### Login

```js
POST {{host}}/auth/Login
```

#### Login Request

```json
{
	"email": "kenan@asaad.com"
	"password": "kenanAsaad123"

}
```

#### Login Response
```js
200 OK
```

```json
{
	"id": "d1312eca-5979-41a1-bfb6-347bb426761b",
	"firstName: "kenan",
	"lastName: "asaad",
	"email": "kenan@asaad.com",
	"token": "eyJhb..z9dqcnXoY"
}
```
