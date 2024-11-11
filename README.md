# Country Info App

This is a Vue.js application that allows users to search for countries and view information about each one, such as its capital (reversed) and region. Users can add countries to a list and remove them as needed.

## Usage

- **Country Search**: Search for countries by name using the search bar.
- **Add and Remove Countries**: Add countries to a list to view details, and remove them with a single click.
- **Responsive Design**: The layout adjusts for mobile, tablet, and desktop screens.

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/Kikres/Countries.git
   ```
  cd Squares
2. **Backend (API)**

   Note: Don't forget to add the appsettings.local.json and reflec the structure in appsettings.json but with the key added.

   Navigate to the `Countries.Server` folder to set up and run the .NET backend:

   - Install dependencies and restore the project:

     ```
     dotnet restore
     ```

   - Run the backend server:

     ```
     dotnet run
     ```

   The API will start on [http://localhost:5100](http://localhost:5100).

3. **Frontend (Vue.js)**

   Navigate to the `Countries.Client` folder to set up and run the React frontend:

   - Install dependencies:

     ```
     npm install
     ```

   - Start the React development server:

     ```
     npm run dev
     ```

   The Vue.js app will run on [http://localhost:5200](http://localhost:5200).


## API Documentation

The API documentation is automatically generated and can be accessed via Swagger UI. Once the backend server is running, you can view the API documentation at:
http://localhost:5101
