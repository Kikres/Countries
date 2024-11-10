<template>
  <div class="container">
    <SearchBar @add-country="addCountry" />
    <CountryList :countries="countries" @remove-country="removeCountry" />
  </div>
</template>

<script>
import SearchBar from './components/SearchBar.vue'
import CountryList from './components/CountryList.vue'

export default {
  components: {
    SearchBar,
    CountryList,
  },
  data() {
    return {
      countries: [],
    }
  },
  methods: {
    addCountry(country) {
      if (this.countries.some((c) => c.name === country.name)) {
        return
      }

      this.countries.push(country)
    },
    removeCountry(name) {
      this.countries = this.countries.filter((c) => c.name !== name)
    },
  },
}
</script>

<style scoped>
* {
  font-family: Arial, sans-serif;
  box-sizing: border-box;
}

.container {
  max-width: 600px;
  margin: 20px auto;
  padding: 1rem;
  background-color: #f0f0f0;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

/* Mobile (small screens) */
@media (max-width: 600px) {
  .container {
    width: 90%;
  }
}

/* Tablet (medium screens) */
@media (min-width: 601px) and (max-width: 1024px) {
  .container {
    width: 70%;
  }
}

/* Desktop (large screens) */
@media (min-width: 1025px) {
  .container {
    width: 60%;
  }
}
</style>
