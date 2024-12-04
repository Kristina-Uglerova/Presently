<template>
  <div class="container d-flex justify-content-center align-items-center min-vh-100">
    <div class="register-form card p-4 shadow-sm" style="max-width: 500px; width: 100%;">
      <form @submit.prevent="handleSubmit">
        <h2 class="mb-4 text-center">Create wish</h2>

        <div class="mb-3">
          <input
              type="text"
              v-model="name"
              class="form-control"
              placeholder="Name"
              required
          />
        </div>

        <div class="mb-3">
          <input
              type="text"
              v-model="notes"
              class="form-control"
              placeholder="Notes"
          />
        </div>

        <div class="mb-3">
          <label for="currency" class="form-label">Currency</label>
          <select id="currency" v-model="currency" class="form-control" required>
            <option v-for="option in currencyOptions" :key="option" :value="option">
              {{ option }}
            </option>
          </select>
        </div>

        <button type="submit" class="pill_button w-100">Create</button>
      </form>
    </div>
    <div class="wave_container"></div>
  </div>
</template>

<script setup>
import {onMounted, ref} from 'vue';
import axios from 'axios';

const currencyOptions = ref(['€', '$']);
const name = ref('');
const notes = ref('');
const currency = ref('');
const userId = ref(2);

const handleSubmit = async () => {
  try {
    if (!name.value || !currency.value) {
      alert('Please fill in all required fields.');
      return;
    }

    const wishData = {
      name: name.value,
      notes: notes.value,
      userId: userId.value,
      bought: false,
      currency: currency.value
    };

    const response = await axios.post('https://localhost:32769/api/wish', wishData);

    console.log('Wish created:', response.data);
    alert('Wish created successfully!');

    name.value = '';
    notes.value = '';
    currency.value = '';
  } catch (error) {
    console.error('Error creating wish:', error);
    alert('Failed to create wish. Please try again.');
  }
};
</script>

<style scoped>
.register-form {
  background-color: #fff;
  border-radius: 8px;
}
</style>