const BASE_URL = 'http://localhost:5200/api/v1/countries'

export const searchByNameAsync = async (query) => {
  query.trim() // Remove leading and trailing whitespace

  // Return empty array if the query is empty
  if (!query) return []

  try {
    const response = await fetch(BASE_URL + `/search/${query}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })

    // Alert the user if there was an error fetching data from the server
    if (!response.ok) {
      alert('Error fetching data from the server')
      throw new Error('Error fetching data from the server')
    }

    return await response.json()
  } catch (error) {
    console.error('Error fetching countries from the backend:', error)

    // Return empty array in case of an error
    return []
  }
}
