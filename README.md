# doctors-and-patients

An ASP.NET Core Web API .NET 6 application which creates local doctors-and-patients API. And uses Angular for front-end.

## :exclamation::exclamation::exclamation: Download and install :exclamation::exclamation::exclamation:

Microsoft SQL Server Management Studio <br>
https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

SQL Server <br>
https://www.microsoft.com/en-us/sql-server/sql-server-downloads

Node Js Latest LTS Version<br>
https://nodejs.org/en/download/

.NET 6.0 <br>
https://dotnet.microsoft.com/en-us/download

Angular <br>
https://angular.io/guide/setup-local <br>

[blog.angular-university.io](https://blog.angular-university.io/getting-started-with-angular-setup-a-development-environment-with-yarn-the-angular-cli-setup-an-ide/)

### To run your program:

If you are new to .NET visit [microsoft.com](https://dotnet.microsoft.com/en-us/learn)

1. You need to clone or download project from GitHub [project page](https://github.com/kristaps-m/doctors-and-patients)
2. You need the .NET Framework and an IDE (integrated development environment) to work with the C# language. [Try this page to get started.](https://www.simplilearn.com/c-sharp-programming-for-beginners-article)

- :exclamation::exclamation::exclamation: You will need data to work with :exclamation::exclamation::exclamation:
- :exclamation: In Visual Studio open Package Manager Console.
- :exclamation: Make sure you are in doctors-and-patients.Data Console window.
- :exclamation: And type 'update-database'
  - more information [here:](https://www.learnentityframeworkcore.com/migrations/commands/pmc-commands)
- To see data in your Microsoft SQL Server Management Studio, add doctors, patients and doctor_patient using swagger tool. More information [here:](https://swagger.io/tools/swagger-ui/)
  - You can also use Postman. More info [here:](https://www.postman.com/)
- more information [learn.microsoft.com](https://learn.microsoft.com/en-us/ef/core/cli/powershell)

3. Open and run project with capable IDE of your choice. I used Visual Studio in example below.

<img src="readme pictures/run.png">

- Or go to in project directory "doctors-and-patients\DoctorsAndPatientsBackend\doctors-and-patients" open powershell or terminal and run project using 'dotnet watch run' command.
- If web browser does not open automatically, go to 'https://localhost:4444/swagger/index.html'

4. Visual Studio should open browser window automaticaly with Swagger project page or go
   [https://localhost:4444/swagger/index.html](https://localhost:4444/swagger/index.html)

<img src="readme pictures/swagger_page.png" width="300">

5. To use doctors-and-patients API, click on 'GET /api/doctor/add' --> 'Try it out' --> 'Execute'. And you will be able to add new Doctor.

- Now you can Create, Read, Update and Delete (CRUD).
- For more information about how to use Swagger visit:
  - [https://learn.microsoft.com](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0)
  - Or you can use Postman [https://www.postman.com/product/what-is-postman/](https://www.postman.com/product/what-is-postman/) for CRUD operations.

6. To use front end. Go to repository "doctors-and-patients\AngularUI" open terminal window or powershell and type
   - 'npm install'
   - then 'ng serve'

- Now go to http://localhost:4200 to see homepage.

7. Now you should be able to see homepage. You can see all doctors and all patients or navigate further to one of doctors.
   - remember to add doctor, patents, and doctor_patent. To see them in front end.

<img src="readme pictures/homepage.png" width="600">

8. Here you can see doctor with id 1, and local link http://localhost:4200/doctor/1

- After clicking 'Create new Patient' Window for creating the patient (for doctor) will appear.

<img src="readme pictures/patient.png" width="500">

9. If you click on 'Create new Patient' then 'New Patient Window' will appear.

- After clicking 'Create Patient for Doctor {id}' new Patient and new DoctorPatient will be added to the database.

<img src="readme pictures/new patient.png" width="500">

10. If you want to run tests, go back to your Visual Studio. In picture below you can see how to run them.

- more information [https://learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/core/testing/)

<img src="readme pictures/tests.png" width="500">

11. Improvements in future:

- [ ] add full CRUD frontend functionality.
- [ ] add more tests.
- [ ] add frontend tests.
- [ ] add authentication method.
- [ ] improve Front End UI and visuals.
- [ ] create Front End using other frameworks.
