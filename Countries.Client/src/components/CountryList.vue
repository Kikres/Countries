<template>
  <ul v-if="countries.length > 0" class="country-list">
    <li v-for="(country, index) in countries" :key="index" @click="removeCountry(country.name)">
      <div class="country">
        <h2>{{ country.name }}</h2>
        <p><strong>Capital (reversed):</strong> {{ country.reversedCapital }}</p>
        <p><strong>Region:</strong> {{ country.region }}</p>
      </div>
    </li>
  </ul>
  <div v-else class="empty-block">
    <span class="icon">&#10547;</span>
    <div class="empty-message">
      <p>Search and add a country to display more information.</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    countries: Array,
  },
  emits: ['remove-country'],
  methods: {
    removeCountry(name) {
      this.$emit('remove-country', name)
    },
  },
}
</script>

<style scoped>
.country-list {
  padding: 0;
  list-style-type: none;
}

.country {
  position: relative;
  background-color: #f0f0f0;
  padding: 16px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  transition: background-color 0.3s ease;
}

.country:hover {
  background-color: #ffe0e0;
}

.country h2 {
  font-size: 24px;
  margin: 0 0 8px;
}

.country p {
  font-size: 16px;
  margin: 4px 0;
}

.country:hover::after {
  content: '❌';
  font-size: 20px;
  color: #ff4c4c;
  position: absolute;
  right: 16px;
  top: 16px;
}

.empty-block {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  font-size: 1.5rem;
  padding-top: 32px;
  color: #666;
}

.icon {
  font-size: 100px;
  margin-bottom: 12px;
  transform: rotate(-90deg);
}

.empty-message {
  width: 60%;
  text-align: center;
  background-color: #ffffff;
  border-radius: 16px;
  padding: 16px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

li {
  width: 90%;
  margin: 8px auto;
}
</style>
