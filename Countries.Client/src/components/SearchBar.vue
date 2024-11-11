<template>
  <div class="search-bar">
    <div>
      <input type="text" v-model="query" placeholder="Search by country name..." />
      <button @click="handleSearch(query)">Search</button>
    </div>
    <ul v-if="countries.length" class="dropdown">
      <li
        v-for="(country, index) in countries"
        :key="index"
        @click="addCountry(country)"
        class="dropdown-item"
      >
        {{ country.name }}
      </li>
    </ul>
  </div>
</template>

<script>
import { searchByNameAsync } from '@/services/CountryService'

export default {
  data() {
    return {
      query: '',
      countries: [],
    }
  },
  emits: ['add-country'],
  methods: {
    async handleSearch(query) {
      if (!query.trim()) {
        this.countries = []
        return
      }
      const result = await searchByNameAsync(query)
      this.countries = result
    },
    addCountry(country) {
      this.query = ''
      this.countries = []
      this.$emit('add-country', country)
    },
  },
}
</script>

<style scoped>
.search-bar {
  position: relative;
  width: 100%;
  max-width: 400px;
  margin: 20px auto;
}

input {
  box-sizing: border-box;
  font-size: 1.2rem;
  width: 100%;
  padding: 10px 12px;
  border: 1px solid #ccc;
  border-radius: 4px 0 0 4px;
}

input:focus,
input:hover {
  border-color: #007bff;
  outline: none;
}

.search-bar:has(ul) input {
  border-bottom-left-radius: 0;
}

.search-bar:has(ul) button {
  border-bottom-right-radius: 0;
}

.search-bar > div {
  display: flex;
}

.search-bar button {
  padding: 10px 12px;
  background-color: #007bff;
  color: #ffffff;
  border: none;
  border-radius: 0 4px 4px 0;

  cursor: pointer;
}

/* Dropdown style */
.dropdown {
  position: absolute;
  width: 100%;
  background-color: #ffffff;
  border: 1px solid #ddd;
  border-top: none;
  border-bottom-left-radius: 4px;
  border-bottom-right-radius: 4px;
  max-height: 150px;
  overflow-y: auto;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  z-index: 1000;
}

.dropdown-item {
  padding: 10px;
  font-size: 1rem;
  color: #333;
}

.dropdown-item:hover {
  background-color: #f0f0f0;
  cursor: pointer;
}

ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
}
</style>
