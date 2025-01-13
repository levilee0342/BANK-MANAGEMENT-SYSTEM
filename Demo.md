**1. Login:** You must select one of the two branches, BENTHANH or TANDINH, and enter the username and password. 
- The software includes three roles: NGANHANG (Bank Management), CHINHANH (Branch Management), and KHACHHANG (Customer). For details about the permissions of each role, you can take a look at the User Role Management section in the README.md file.
![image](https://github.com/user-attachments/assets/36dd15e9-d7f6-4a09-9402-4790bfcac950)
![image](https://github.com/user-attachments/assets/0eac9851-995d-4563-bf2e-3673b3191dc9)

**2. Create Account:** When registering a new account in the system, you must select one of the three roles: NGANHANG (Bank Management), CHINHANH (Branch Management), or KHACHHANG (Customer). 
  - NGANHANG (Bank Management) can only create NGANHANG accounts
  - CHINHANH (Branch Management) can create accounts for CHINHANH and KHACHHANG
  - KHACHHANG (Customer) is not allowed to create accounts. 
![image](https://github.com/user-attachments/assets/32a913e0-e325-476b-af1c-237e0b405b4c)
![image](https://github.com/user-attachments/assets/55882797-c064-49a2-8a83-40d9d094db28)

**3. Employee Management:**
  - Logging in as NGANHANG allows viewing employee information for both branches.
  - Logging in as CHINHANH allows editing employee information for their respective branch only.
  - Logging in as KHACHHANG does not grant access to this feature.

**View branch information:** Logging in as NGANHANG allows viewing information for both BẾN THÀNH and TÂN ĐỊNH branches.
![image](https://github.com/user-attachments/assets/c94b4b40-56f3-44bf-aa81-acc7e492e96b)
![image](https://github.com/user-attachments/assets/3a63b8be-364b-482a-b2a6-d60d9d26f629)

**Edit branch information:** Logging in as CHINHANH allows editing information for the BẾN THÀNH branch if the user belongs to that branch.
![image](https://github.com/user-attachments/assets/34ac5c44-e702-4591-9d0d-12c8f5bba76a)

**Transfer employees between branches:** Transfer employees between branches: Logging in as CHINHANH allows transferring employees between the BẾN THÀNH and TÂN ĐỊNH branches.
![image](https://github.com/user-attachments/assets/6d0cbf9b-1be9-4fff-81c4-463b75ca0364)
![image](https://github.com/user-attachments/assets/adcd7597-54c7-4224-8f46-4e66ab344645)
![image](https://github.com/user-attachments/assets/e2ee3805-6dfc-4679-beea-747d2090f5b7)

**4. Customer Management:**
  - NGANHANG role: Can view customer information for both BẾN THÀNH and TÂN ĐỊNH branches.
  - CHINHANH role: Can edit customer information for their respective branch.
  - KHACHHANG role: Access to this feature is not allowed.

View customer information: Logging in as NGANHANG allows viewing customer information for both BẾN THÀNH and TÂN ĐỊNH branches.
![image](https://github.com/user-attachments/assets/18a06190-c173-4c37-bf39-3881b9f3bc60)
![image](https://github.com/user-attachments/assets/f535af64-9ef1-45dc-8dbf-05a994cd14d9)

Edit customer information: Logging in as CHINHANH allows editing customer information for their current branch.
![image](https://github.com/user-attachments/assets/28cb4247-71be-4c1b-b3be-5137c18fc012)

Open customer accounts: Logging in as CHINHANH allows opening accounts for customers in their current branch or another branch.
![image](https://github.com/user-attachments/assets/1aabc5aa-0547-44c7-a682-31fe30453dd9)
![image](https://github.com/user-attachments/assets/27b1fc23-502b-4732-9c80-ea1ef63fee36)
![image](https://github.com/user-attachments/assets/445964c3-3350-436c-8e14-9f466be1b914)

**5. Account and Transaction:**
  - NGANHANG role: Can view account information for customers across both BẾN THÀNH and TÂN ĐỊNH branches.
  - CHINHANH role: Can perform transactions for customers within their branch.
  - KHACHHANG role: Access to this feature is not allowed.

View account information: Logging in as NGANHANG allows viewing account details for customers in both BẾN THÀNH and TÂN ĐỊNH branches.
![image](https://github.com/user-attachments/assets/e5dcbbba-95e5-4c47-aa02-b8f1d90c3cbf)

Deposit money: Logging in as CHINHANH allows performing deposit transactions at their respective branch.
![image](https://github.com/user-attachments/assets/9570436b-dd69-4b09-8ffe-fffc10802d83)
![image](https://github.com/user-attachments/assets/4920a312-5264-4235-9fe3-f0ff85194e1a)
![image](https://github.com/user-attachments/assets/4f4e745a-daed-4500-ba4d-663555d504ea)

Withdraw money: Logging in as CHINHANH allows performing withdrawal transactions at their respective branch.
![image](https://github.com/user-attachments/assets/c9f7a400-4740-4c2c-be4f-a9c22578713a)
![image](https://github.com/user-attachments/assets/1b1e003f-c276-444b-aff2-ab46472c4033)
![image](https://github.com/user-attachments/assets/48987369-56af-45b2-9d5d-e29ddf37db35)

Transfer money: Logging in as CHINHANH allows performing money transfer transactions within their branch.
![image](https://github.com/user-attachments/assets/64195ce5-dbd4-46ce-8684-08852e6ae6e1)
![image](https://github.com/user-attachments/assets/232c9637-6944-475b-b0b4-fc31cabd6af2)
![image](https://github.com/user-attachments/assets/ffd403dd-9180-4fff-b05c-3af837c82fed)


**6. Report**
  - NGANHANG role: Can view reports for both BẾN THÀNH and TÂN ĐỊNH branches.
  - CHINHANH role: Can view reports for their current branch only.
  - KHACHHANG role: Can only view their transaction statement.

Transaction history within a specific period:
![image](https://github.com/user-attachments/assets/7e0c6504-20b2-493d-b7fa-fd7cb55b204f)
![image](https://github.com/user-attachments/assets/8c0e3399-7dbd-4282-888d-3e61aa9e1dca)
![image](https://github.com/user-attachments/assets/6c5a732a-dd42-4df0-ba3b-b03f32a40c82)

List of accounts opened within a specific period
![image](https://github.com/user-attachments/assets/9705fc47-9560-4db8-b218-a04ae94779ab)
![image](https://github.com/user-attachments/assets/f4e696b1-9599-4023-9419-f98921d85565)
![image](https://github.com/user-attachments/assets/2aa3226d-7079-408f-9251-1c12ec9444ca)

List of customers for each branch
![image](https://github.com/user-attachments/assets/ffccf4e2-cc0d-46c3-8ff5-37a0f588f91a)
![image](https://github.com/user-attachments/assets/05635ff3-37ee-4268-b374-1be75e675ebd)
![image](https://github.com/user-attachments/assets/7ecd334e-5a39-4ed6-9c65-764e0ec896de)




