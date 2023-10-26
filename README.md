<h1>MS.BlogMVC - Blog Site</h1>

<img src="/readme-images/home.png" />

## Table of Contents

- [Project Features](#project-features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Contact](#contact)
- [Gallery](#gallery)

## Project Features

- User System: Register and login functionality for users.
- Blog Posts: Ability to add, edit, and delete blog posts.
- Comments: Users can add comments on blog posts.
- Likes: Users can like blog posts.
- Admin Functionality: Admin users can manage blog posts, tags, and regular users.
- Super Admin: Super admin users can add users who are admins.
- Image Upload: Cloudinary integration for storing and uploading blog post images.
- Form Validations: Server-side and client-side form validations.
- MVC Architecture: Project follows the principles of MVC (Model View Controller).

## Technologies Used

- C# ASP.NET 7.0
- SQL (local MySQL)
- Cloudinary (for image storage)
- Froala Text Editor
- MVC Interface, Repository, Controller, Model View principles

## Installation

To run the project locally, follow these steps:

1. Clone the repository:

    `git clone https://github.com/yosikari/MS.BlogMVC.git`

2. Set up the database:
   - Create two databases, one for users and one for blog posts.
   - Update the database connection strings in the project configuration files (`appsettings.json` or similar).

3. Install the necessary dependencies and packages.

4. Build and run the project.

## Usage

1. Access the project through the browser.

2. Register a new user or log in with existing credentials.

3. Explore the blog posts, add comments, and like posts.

4. Admin users can manage blog posts, tags, and regular users.

5. Super admin users can also add users who are admins.

## Contact

If you have any questions or feedback, feel free to contact me at yosikari@gmail.com.

## Gallery

#### Add Blog Post
<img src='/readme-images/addBlogPost.gif' weight='600'/>

#### Add or Delete User
<img src='/readme-images/addDeleteUser.gif' weight='600'/>

#### Blog Full View
<img src='/readme-images/blogFullView.png' weight='600'/>

#### Blog Preview
<img src='/readme-images/blogPreview.png' weight='600'/>

#### Edit or Delete Blog
<img src='/readme-images/editDelete.gif' weight='600'/>

#### Likes and Comments Functionality
<img src='/readme-images/likesComments.gif' weight='600'/>

#### Login / Sign-up Page
<img src='/readme-images/login.png' weight='600'/>

#### Tag Page
<img src='/readme-images/tag.png' weight='600'/>
