## Diagnostic-Management-System
### INTRODUCTION 
##### A Diagnostic Management System (DMS) is a comprehensive framework designed to streamline and enhance the process of diagnosing and managing various conditions, whether in healthcare, automotive, or other fields. It typically integrates data collection, analysis, and decision-making tools to facilitate accurate diagnoses and efficient management 

##  Case Study
##### The purpose of the project entitle as “Diagnostic Management System” is find 
##### out the patients those who need to be diagnosed. It deals with the collection of 
 ##### patients for various diagnosis centers like service provider. The main function 
##### of the system is register, search for diagnostic center according to Hospital, 
##### store patient details for diagnosis. In the diagnostic management system people 
 ##### can login using a username and Password. It is accessible by any public those 
##### whose need diagnosis service and accessible for service provider those who 
#### provide the software to the public. To use the software they need to register in 
##### the system. Any public can add data into the database by registration. Only 
##### admin can see the patient details. One patient can’t see the other patient’s info. 
##### The system has the facility to give a unique id to every patient. Anyone can 

##### search their desired diagnosis center by search button. They can show all details 
##### about the selected diagnosis center of the Hospital and know about the services 
##### cost also can check the rating of diagnostic center and which center is best for 
##### their required test. Patient can select service which they need and also can 
#####  payment via (Bikash, Nogod) money transition platform. Patient can add review 
##### according to service after taking service which help toNogod)opular diagnosis 
##### center. They can comment about the center. Patients can see the status of the 
##### service processing (pending, delivered, waiting). A patient can be included into 
##### special membership. Every patient those who are   included in special member 
##### has unique membership id. Membership id helps to get special discount 
##### according to their services. 
##### The admin of the service provider also can access the system by login. Admin 
##### can add new diagnostic centers, view order (diagnosis service) and view earning 
##### of their service. The diagnosis process is controlled by admin. Admin provides 
##### the patients information to the diagnostic center. 
##### It also aims at providing low-cost reliable automation of the existing systems. 
##### The system also provides excellent security of data at every level of user and 
##### provides robust and reliable storage facilities. The System provider also 
##### benefited in the patient’s vat and payment of diagnosis center. 

# SCHEME DIAGRAM
![Capture (2)](https://github.com/user-attachments/assets/fafb4d30-66df-4db1-b458-1af64b43b159)

# TRANSATION DIAGRAM 
![Capture](https://github.com/user-attachments/assets/26d4569f-a6e2-4003-81bf-e7b8e511da2c)

# DATA BASE QUERY
Diagnostic Service Provider System Table Query

1.	Login Table
CREATE TABLE [dbo].[Login] (
    [ID]       INT IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Type]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([Username] ASC)
);

2.	Patient Table

CREATE TABLE [dbo].[Patient] (
    [P_ID]  AS ('P-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [P_NAME]    NVARCHAR (100) NOT NULL,
    [P_AGE]     INT            NOT NULL,
    [P_NUMBER]  NVARCHAR (20)  NOT NULL,
    [P_ADDRESS] NVARCHAR (255) NOT NULL,
    [ID]        INT IDENTITY (1, 1) NOT NULL,
    [Username]  NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([P_ID] ASC),
    CONSTRAINT [FK_Username] FOREIGN KEY ([Username]) REFERENCES [dbo].[Login] ([Username])
);

3.	Diagnostic_Center Table

CREATE TABLE [dbo].[Diagnostic_Center] (
    [D_ID]      AS ('D-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [D_NAME]    NVARCHAR (100) NOT NULL,
    [D_ADDRESS] NVARCHAR (255) NOT NULL,
    [ID]        INT IDENTITY (1, 1) NOT NULL,
    [P_ID]      NVARCHAR (12)  NULL,
    PRIMARY KEY CLUSTERED ([D_ID] ASC),
    CONSTRAINT [FK_Pid] FOREIGN KEY ([P_ID]) REFERENCES [dbo].[Patient] ([P_ID])
);

4.	Services Table

CREATE TABLE [dbo].[Services] (
    [S_ID]    AS ('S-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [S_NAME]  NVARCHAR (100) NOT NULL,
    [S_PRICE] NVARCHAR (50)  NOT NULL,
    [ID]      INT IDENTITY (1, 1) NOT NULL,
    [D_ID]    NVARCHAR (12)  NULL,
    PRIMARY KEY CLUSTERED ([S_ID] ASC),
    CONSTRAINT [FK_Did] FOREIGN KEY ([D_ID]) REFERENCES [dbo].[Diagnostic_Center] ([D_ID])
);
5.	Orders Table

CREATE TABLE [dbo].[Orders] (
    [O_ID]    AS ('O-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [D_ID]    NVARCHAR (12) NULL,
    [P_ID]    NVARCHAR (12) NULL,
    [ID]      IN IDENTITY (1, 1) NOT NULL,
    [O_DATE]  DATETIME      NULL,
    [O_PRICE] FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([O_ID] ASC),
    CONSTRAINT [FK_PidO] FOREIGN KEY ([P_ID]) REFERENCES [dbo].[Patient] ([P_ID]),
    CONSTRAINT [FK_DidO] FOREIGN KEY ([D_ID]) REFERENCES [dbo].[Diagnostic_Center] ([D_ID])
);

6.	Membership Table
CREATE TABLE [dbo].[Membership] (
    [M_ID]   AS ('M-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [P_ID]   NVARCHAR (12) NULL,
    [M_TYPE] NVARCHAR (50) NOT NULL,
    [ID]     INT IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([M_ID] ASC),
    CONSTRAINT [FK_PidM] FOREIGN KEY ([P_ID]) REFERENCES [dbo].[Patient] ([P_ID])
);

7.	Admin Table

CREATE TABLE [dbo].[Admin] (
    [A_ID] AS ('A-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [D_ID] NVARCHAR (12) NULL,
    [O_ID] NVARCHAR (12) NULL,
    [M_ID] NVARCHAR (12) NULL,
    [ID]   INT IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([A_ID] ASC),
    CONSTRAINT [FK_Oid] FOREIGN KEY ([O_ID]) REFERENCES [dbo].[Orders] ([O_ID]),
    CONSTRAINT [FK_Mid] FOREIGN KEY ([M_ID]) REFERENCES [dbo].[Membership] ([M_ID]),
    CONSTRAINT [FK_DidA] FOREIGN KEY ([D_ID]) REFERENCES [dbo].[Diagnostic_Center] ([D_ID])
);

8.	Payment Table

CREATE TABLE [dbo].[Payment] (
    [PAY_ID]         AS ('Pay-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [P_ID]           NVARCHAR (12) NULL,
    [PAY_METHOD]     NVARCHAR (50) NULL,
    [O_ID]           NVARCHAR (12) NULL,
    [ID]             INT IDENTITY (1, 1) NOT NULL,
    [PAYMENT_NUMBER] NVARCHAR (11) NOT NULL,
    PRIMARY KEY CLUSTERED ([PAY_ID] ASC),
    CONSTRAINT [FK_PidPayment] FOREIGN KEY ([P_ID]) REFERENCES [dbo].[Patient] ([P_ID])
);

9.	Rating Table

CREATE TABLE [dbo].[Rating] (
    [R_ID]    AS ('R-'+CONVERT([nvarchar](10),[ID])) PERSISTED NOT NULL,
    [P_ID]    NVARCHAR (12)  NULL,
    [D_ID]    NVARCHAR (12)  NULL,
    [O_ID]    NVARCHAR (12)  NULL,
    [COMMENT] NVARCHAR (100) NULL,
    [STAR]    INT            NULL,
    [ID]      INT IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([R_ID] ASC),
    CONSTRAINT [FK_OidR] FOREIGN KEY ([O_ID]) REFERENCES [dbo].[Orders] ([O_ID]),
    CONSTRAINT [FK_PidR] FOREIGN KEY ([P_ID]) REFERENCES [dbo].[Patient] ([P_ID]),
    CONSTRAINT [FK_DidR] FOREIGN KEY ([D_ID]) REFERENCES [dbo].[Diagnostic_Center] ([D_ID])
);

10.	DiagnosticCenterService

CREATE TABLE [dbo].[DiagnosticCenterService] (
    [D_ID] NVARCHAR (12) NOT NULL,
    [S_ID] NVARCHAR (12) NOT NULL,
    PRIMARY KEY CLUSTERED ([D_ID] ASC, [S_ID] ASC),
    CONSTRAINT [FK_DidDCS] FOREIGN KEY ([D_ID]) REFERENCES [dbo].[Diagnostic_Center] ([D_ID]),
    CONSTRAINT [FK_SidDCS] FOREIGN KEY ([S_ID]) REFERENCES [dbo].[Services] ([S_ID])
);








