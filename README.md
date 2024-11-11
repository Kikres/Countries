# Country Info App

This is a Vue.js application that allows users to search for countries and view information about each one, such as its capital (reversed) and region. Users can add countries to a list and remove them as needed.

## Usage

Search for a Country: Type in the search bar to find a country.
Add Country: Click on a country from the dropdown to add it to the list.
Remove Country: Click the remove icon on an added country to remove it from the list.

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/Kikres/Countries.git
   ```
  cd Squares
2. **Backend (API)**

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

   The React app will run on [http://localhost:5200](http://localhost:5200).


## API Documentation

The API documentation is automatically generated and can be accessed via Swagger UI. Once the backend server is running, you can view the API documentation at:
http://localhost:5101
