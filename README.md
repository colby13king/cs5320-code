Home Page
http://localhost:5228/

Cart Page
http://localhost:5228/Cart?returnUrl=%2F

Checkout Page
http://localhost:5228/Order/Checkout

Admin
http://localhost:5228/admin/

Admin Products
http://localhost:5228/admin/products

Admin Orders
http://localhost:5228/admin/orders

On the Home Page, you may filter the product list using the buttons on the left side of the Home page; Home, Engineering Tools, Text Editors.

The purchase an item, add it to the Cart, then proceed to Checkout.

The Solution contains 5 projects
1. LicenseAssetManager - the main web application, responsible for making a verifying orders
2. LicenseAssetManagerSDK - a plugin software developers can use to add LicenseAssetManager support to their application for license verificatioin
3. TestLicenseAssetManager - a Unit Test project
4. LicenseAssetManagerWpfTestApp - a test application demonstrating the use the the LicenseAssetManagerSDK plugin to verify license
5. BlazorApp1 - a test project using Blazor technology. Used as a reference for adding Blazor support in the LicenseAssetManager application.

A Software License for Our Project
Copyright 2024 Johnny C. King and John L Williams Jr
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
This license is also controlled by the Manning Publisher License, who provided a great deal of guidance and source material in the creation of the application. Please read the details in the link provided below.
https://www.manning.com/ebook-license
Source Code Supplementary Material
Any source code files provided as a supplement to the book are freely available to the public for download. Reuse of the code is permitted, in whole or in part, including the creation of derivative works, provided that you acknowledge that you are using it and identify the source: Pro ASP.NET Core 7 10th ed., Adam Freeman, Manning Publishing, 2023.

How to run the main application.
Open the Solution in Visual Studio.
Make sure the LicenseAssetManager is set to the starting project.
Click on the "http" button in Visual Studio.
A command terminal will open showing the commands that are being run.
Your browser should open to the home page.

How to run test cases.
In Visual Studio, open the Test Explorer window.
Select "Run all test in view."

Maintenance Task For CS5340
The maintenance task completed during the S2025 semester were mostly perfective in nature. 
This included generating UML class diagrams for the entire main project and adding more unit test cases to the TestLicenseAssetManager project.
The UML Class diagrams can be found in the file ".\LicenseAssetManager\LicenseAssetManager\docs\Research\EA\EA.qea"
This file can only be opened using the Enterprise Archtitect tool, which was used to generate the UML class diagrams.
To download a free 30 day trial version of Enterprise Architect, go to https://sparxsystems.com/
The current student/instructor cost is $123 for a fixed license and $160 for a floating license.
One task involved refactoring the implementation of the Blazor app file, which only required renaming the Blazor control file to App.razor and fixing the name in the 
program.cs file.
