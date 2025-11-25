# Top Scorers Assessment

This solution consists of four projects that work together to process CSV data, store it in a shared SQLite database, and expose the processed information through a Web API.

## Project Structure

The solution contains the following projects:

### **1. Data**

Responsible for:

* Defining the EF Core `DatabaseContext`
* Defining entities
* Providing a `DatabaseInitialiser` for creating a shared SQLite database

### **2. CsvProcessor (Console Application)**

Responsible for:

* Initialising/using the shared SQLite database
* Importing and processing data from CSV files
* Saving processed information into the database

The console app directly depends on:

* The `DatabaseContext`
* A `DataProcessor` for processing the CSV data

Note that the CSV processor assumes that:
* All CSV files have three columns (rows with more or less columns will be ignored)
* The score can be parsed to an int

### **3. ScorerApi**

Responsible for:

* Initialising/using the shared SQLite database
* Exposing the imported data via HTTPS endpoints
* Adding additional data into the database

### **4. Application**

Responsible for:

* Injecting `DatabaseContext` through dependency injection
* Applying a service layer to separate controllers from persistence logic

For the purposes of this project, the Application and CsvProcessor both use the **same SQLite database file**, determined by `DatabaseInitialiser`.

---

## Shared Database Strategy

### SQLite File Location

Both the Application and Console App use the same SQLite file located in the repository at:

```
Database/TestData.db
```

A central path is resolved using `DatabaseInitialiser`, which:

* Loads configuration from `appsettings.<environment>.json`
* Resolves a shared database path
* Creates the folder and file if needed

---

## How to Run the System

This project runs on .NET 8.0.

### **1. Run the console app**

This step:

* Initializes the database if it doesn’t exist
* Creates tables if they don't exist
* Imports CSV file data into the database
* Displays the top scorer name(s) and the highest score from the CSV

**Run:**

```
dotnet run --project CsvProcessor
```

If a valid file path and CSV delimiter are specified, the console result should look like this:
<img width="1482" height="757" alt="image" src="https://github.com/user-attachments/assets/2050c0ec-50e1-4b16-ac9f-5b2ede6e5205" />
given the `TestData.csv`

<img width="346" height="127" alt="image" src="https://github.com/user-attachments/assets/c3942527-68cd-4b90-a25d-a7d471a8efb0" />

### **2. Run the Web API**

The API:

* Uses the same database
* Exposes the data via endpoints
* Contains a simple Swagger page that can be used to interact with the endpoints

**Run:**

```
dotnet run --project ScorerApi
```
Then the Swagger page can be accessed at `https://localhost:7151/swagger/index.html`

---

## Entity Framework Core

This project uses EF Core with:

* SQLite provider
* `EnsureCreated()` instead of migrations (sufficient for this assignment)

---

## Summary

This project implements a full workflow:

1. Console app uses a shared SQLite database and imports data
2. The API exposes the processed data, and allows adding more data
3. A shared Data project hosts EF Core models and DbContext
4. Database path resolution ensures both applications work with the same file, for easy local development with SQLite
