# CoursesManagementApp 🎓

A Windows Forms application built with C# and SQL Server LocalDB, designed to manage university courses and exam periods. Developed as part of a software design course project.

---

## 🚀 Features

- Add new university courses with ECTS credits  
- Add and manage exam periods with start/end dates  
- Assign courses to specific exam periods with a scheduled exam date  
- Display all courses assigned to an exam period, sorted by exam date  
- Input validation (required fields, value ranges)  
- Confirmation prompts before saving or removing data  

---

## 🛠️ Technologies Used

- C# (.NET Framework)  
- WinForms  
- SQL Server LocalDB (`CoursesManagementDB`)  
- ADO.NET (manual SQL commands)  
- Visual Studio  

---

## 📁 Project Structure

- `BrokerDB/` – Database connection (Broker pattern)  
- `ControllerAP/` – Application logic/controller  
- `Domain/` – Data models (Course, ExamPeriod, etc.)  
- `Forms/` – UI Windows Forms (Main Form, ExamPeriod Form, etc.)  

---

## 🗃️ Database Design

**Database name:** `CoursesManagementDB`

### Tables:

#### Course
```sql
CREATE TABLE Course (
    id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(255) NOT NULL,
    ects INT NOT NULL
);
```

#### ExamPeriod
```sql
CREATE TABLE ExamPeriod (
    id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(30) NOT NULL,
    startDate DATE NOT NULL,
    endDate DATE NOT NULL
);
```

#### ExamPeriodCourse
```sql
CREATE TABLE ExamPeriodCourse (
    id_examperiod INT NOT NULL,
    id_course INT NOT NULL,
    date DATETIME NOT NULL,
    PRIMARY KEY (id_examperiod, id_course),
    FOREIGN KEY (id_examperiod) REFERENCES ExamPeriod(id),
    FOREIGN KEY (id_course) REFERENCES Course(id)
);
```

---

## ▶️ How to Run

1. Clone the repository or download the ZIP.  
2. Open `CoursesManagementApp.sln` in Visual Studio.  
3. Create the `CoursesManagementDB` database and run the SQL scripts above.  
4. Run the project (`F5`) and test all features via the Windows Forms UI.  

---

## 📄 License

This project is provided for educational and learning purposes.

---

## 👤 Author

- GitHub: [@nikoladobr](https://github.com/nikoladobr)  
- Academic year: 2023/2024
