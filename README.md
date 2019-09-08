# NetCoreWebApi

This project was generated with Visual Studion 2019 Community Edition.

## Problem to Solve

**Build a simple API that allows:**
* Adding customers.
* First name, last name and date of birth fields.
* Editing customers.
* Deleting customers.
* Searching for a customer by partial name match (first or last name).

**Tech**
* ASP.NET Core 2.2 API
* In memory entity framework store
* Dependency injection
* Basic XUnit tests
* Swagger / OpenAPI support


## Implementaion Notes
* Used Standard template to create a web API with ASP.NET Core
* Besides filtering via First name or Last Name or both, additional implementaion of paging has also been done.

## Links
* Project configured to run on ssl port  44368
* Launch URL https://localhost:44368/api/customer
* Swagger documentation available on https://localhost:44368/swagger/index.html

## Additional Files
1. Postman COllection File used "*.NetCoreWebApi.postman_collection.json*"
2. Class Diagram reated via a hack "*NetCoreWebApiClasses.cd*"

## To improve on
* More Unit Test Cases
* Use input files for seed data
* Filtering to use additional operators for exclusion
