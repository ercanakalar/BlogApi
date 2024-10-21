# Blog Application - Full Stack Project


You can Sign Up first.  Then, It will route you to the blog page. You can see the all blogs with the user, the count of the comment, and some info of the blog. There also have a route to Read More to go to the blog's page. You can reach the blog and it's comments. Also, the user can comment. 

### Backend Setup

1. **Navigate to the backend directory**:
    ```bash
    cd blog
    ```

2. **Restore dependencies**:
    ```bash
    dotnet restore
    ```

3. **Create the database table**:
    ```bash
    dotnet ef migrations add InitialCreate
    ```

4. **Update the database**:
    ```bash
    dotnet ef database update
    ```

5. **Run the backend**:
    ```bash
    dotnet run
    ```

### Frontend Setup

1. **Navigate to the frontend directory from the project root**:
    ```bash
    cd frontend
    ```

2. **Install dependencies**:
    ```bash
    npm install
    ```

3. **Run the frontend**:
    ```bash
    npm run dev
    ```

### Blog Posts
- `GET /api/blog`: Fetch all blog posts.
- `GET /api/blog/{id}`: Fetch a specific blog post by ID.
- `POST /api/blog`: Create a new blog post (Requires authentication).
- `PUT /api/blog/{id}`: Update a blog post (Requires authentication).
- `DELETE /api/blog/{id}`: Delete a blog post (Requires authentication).

### Comments
- `POST /api/blog/comment`: Add a comment to a blog post (Requires authentication).
- `GET /api/blog/comment/{blogId}`: Fetch comments for a specific blog post.

## Features

- **User Authentication**: Users can sign up and log in to manage their blog posts and comments.
- **Blog Posts**: Users can create, update, and delete their own blog posts.
- **Comments**: Users can view and comment on blog posts.
