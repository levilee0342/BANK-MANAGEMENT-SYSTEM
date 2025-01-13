# Banking Management Application

## Overview

This project is a comprehensive **Banking Management Application** designed to manage customer accounts, employee records, and transactions across distributed branches. The application includes an intuitive interface, supports SQL Server for data handling, and ensures secure access controls for different user roles.

#### **Screenshots**

##### 1. Customer management
This is the interface for managing customers at a branch.
![image](https://github.com/user-attachments/assets/cc3badb6-df55-4761-9da3-7658d63b814c)

##### 2. Employee management
This is the interface for managing employees at a branch.
![image](https://github.com/user-attachments/assets/47eb30f8-5cea-4dd6-977c-5e6614ea1881)

##### 3. Transaction management
This is the interface for managing employees at a branch.
![image](https://github.com/user-attachments/assets/bf861367-bfa5-43ed-bc84-21eb3315a047)

### You can check out the full project demo at: 
    https://github.com/levilee0342/Bank-Management-System/blob/main/Demo.md

## Key Features

### Database Distribution

The **NGANHANG** database is distributed across three servers to optimize performance and ensure branch-specific data accessibility:
1. **Server 1**: Stores customer data and transactions for the **BENTHANH** branch.
2. **Server 2**: Stores customer data and transactions for the **TANDINH** branch.
3. **Server 3**: Consolidates customer data from both branches for overarching operations.

> **Note**: Each customer registers with only one branch but can own multiple accounts across branches.

---

### Application Modules

#### **1. Customer Management**
- Add, update, or delete customer information.
- Open new accounts for existing customers with intuitive SubForms.

#### **2. Employee Management**
- Manage employee records, including adding, removing, and editing details.
- Transfer employees between branches seamlessly.

#### **3. Transaction Management**
- Enable deposit, withdrawal, and fund transfers for customers.

#### **4. Reporting and Analytics**
- **Account Statements**:
  Generate detailed statements for specific accounts over a chosen period, including:
  - Opening balances
  - Transaction history
  - Closing balances
- **Branch-Specific Analysis**:
  - List accounts opened within a specific timeframe.
  - Sort customers by branch and alphabetically by name.

---

### User Role Management

The application supports three user roles, ensuring data security and functional segregation:

1. **Bank Management Group (NGANHANG)**:
   - Access data and reports for any branch.
   - Create new accounts within the same group.

2. **Branch Management Group (ChiNhanh)**:
   - Full control over the branch's data.
   - Create new accounts within the same group.

3. **Customer Group (KhachHang)**:
   - View personal account statements only.
   - Restricted from account creation.

> **Dynamic Access Control**: Permissions are assigned during account creation and enforced on login to determine access to specific partitions or branches.

---

## Technology Stack
- **Frontend**: **DevExpress**, utilizing its powerful controls to deliver a professional and responsive design.
- **Backend**: C#
- **Database**: SQL Server
- **Languages & Tools**:
  - **Development Language**: C#
  - **Visual Studio**: For building the interface and logic code, ensuring a seamless development process.
  - **SQL Server Management Studio**: For data queries, transactions, and enforcing constraints.
---

## How to Use

### Setup Instructions:
1. **Database Configuration**:
   - Update database connection strings in 'App.config' and 'Program.cs'.
     
2. **Run the Application**:
   - Use Visual Studio.

### Features in Action:
1. Add new customers, manage employee records, and process transactions.
2. Generate account statements or analyze branch performance.
3. Utilize role-specific login to ensure secure data access.

---

## Example Usage

1. Log in to the application with a valid user role.
2. Navigate to:
   - **Customer Management**: Add or update customer details.
   - **Transaction Management**: Process deposits, withdrawals, or transfers.
3. Access detailed **account statements** and **branch-level reports**.
4. Ensure secure user access based on the assigned permissions.

---

## Contact

Thank you for reviewing my project!  
For more information or inquiries, feel free to reach out at:  
📧 **leetuan0342@gmail.com**

---
