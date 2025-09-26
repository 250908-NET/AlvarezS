# Event Manager API

This API allows you to manage **attendees** and **events**, including registering attendees, managing event details, and linking attendees to events. Below are all available endpoints with their route parameters and request body requirements.

## Attendee Endpoints

### 1. Register an Attendee
- **Route:** `POST /attendees`
- **Request Body:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phone": "string"
}
```
- Creates a new attendee with the provided information.
- All fields are required.
---

### 2. Update an Attendee
- **Route:** `PUT /attendees/{id}`
- **Route Params:** `id` (int): The unique ID of the attendee to update.  
- **Request Body:**
```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phone": "string"
}
```
- Updates the specified attendee’s details.
- All fields are optional.
---
### 3. Delete an Attendee
- **Route:** `DELETE /attendees/{id}`
- **Route Params:** `id` (int): The unique ID of the attendee to delete.  
- Deletes the Attendee.
---

### 4. Get all Attendees
- **Route:** `GET /attendees`
- Returns a list of all attendees showing their `id`, `firstName`, and `lastName`.
---
### 5. Get an Attendee
- **Route:** `GET /attendees/{id}`
- **Route Params:** `id` (int): The unique ID of the attendee to update.

- Gets the specified attendee’s details.

## Event Endpoints

### 1. Register an Event
- **Route:** `POST /events`
- **Request Body:**
```json
{
  "title": "string",
  "description": "string",
  "location": "string",
  "startDate": "YYYY-MM-DD",
  "endDate": "YYYY-MM-DD",
  "startTime": "HH:MM",
  "endTime": "HH:MM"
}
```
- Creates a new event with the provided details.
- All fields are required.

---
### 2. Update an Event
- **Route:** `PUT /events{id}`
- **Route Params:** `id` (int): The unique ID of the event to update.  
- **Request Body:**
```json
{
  "title": "string",
  "description": "string",
  "location": "string",
  "startDate": "YYYY-MM-DD",
  "endDate": "YYYY-MM-DD",
  "startTime": "HH:MM",
  "endTime": "HH:MM"
}
```
- Updates the event with the provided details.
- All fields are optional.
---
### 3. Delete an event
- **Route:** `DELETE /events/{id}`
- **Route Params:** `id` (int): The unique ID of the event to delete.  
- Deletes the event.
---

### 4. Get all event
- **Route:** `GET /events`
- Returns a list of all events showing their `id`, `title`, and `description`.
---
### 5. Get an event
- **Route:** `GET /events/{id}`
- **Route Params:** `id` (int): The unique ID of the event to update.

- Gets the specified event’s details.

## Event-Attendee Relationship Endpoints

### 1. Register an Attendee to an Event
- **Route:** `POST /events/{eventId}/Attendee/{attendeeId}`
- **Route Parameters:**
  - `eventId` (int): ID of the event.
  - `attendeeId` (int): ID of the attendee.
- Registers the specified attendee for the given event.

---

### 2. Get All Attendees at an Event
- **Route:** `GET /event/{eventId}/attendees`
- **Route Parameters:**
  - `eventId` (int): ID of the event.
- Returns a list of attendees registered for the specified event.

---

### 3. Get All Events an Attendee is Signed Up For
- **Route:** `GET /attendee/{attendeeId}/events`
- **Route Parameters:**
  - `attendeeId` (int): ID of the attendee.
- Returns a list of events the attendee is registered for.

---

### 4. Delete an Attendee from an Event
- **Route:** `DELETE /events/{eventId}/Attendees/{attendeeId}`
- **Route Parameters:**
  - `eventId` (int): ID of the event.
  - `attendeeId` (int): ID of the attendee.
- Removes the attendee from the specified event.
