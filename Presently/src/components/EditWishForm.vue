<template>
  <div class="container d-flex justify-content-center align-items-center min-vh-100">
    <div class="register-form card p-4 shadow-sm" style="max-width: 500px; width: 100%;">
      <form @submit.prevent="handleSubmit">
        <h2 class="mb-4 text-center">Edit wish</h2>

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

        <button type="submit" class="pill_button w-100">Save changes</button>
        <button type="button" @click="deleteWish" class="pill_button w-100 mt-2">Delete wish</button>
      </form>
    </div>
    <div class="wave_container"></div>
  </div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';
import { useRoute, useRouter } from 'vue-router';

const router = useRouter();
const route = useRoute();
const wishId = route.params.id;
const currencyOptions = ref(['€', '$']);
const name = ref('');
const notes = ref('');
const currency = ref('');

const getWishDetails = async () => {
  try {
    const response = await axios.get(`https://localhost:32769/api/wish/${wishId}`);
    const wish = response.data;
    name.value = wish.name;
    notes.value = wish.notes;
    currency.value = wish.currency;
  } catch (error) {
    console.error('Error fetching wish details:', error);
    alert('Failed to load wish details.');
  }
};

const handleSubmit = async () => {
  try {
    if (!name.value || !currency.value) {
      alert('Please fill in all required fields.');
      return;
    }
    const updatedWish = {
      name: name.value,
      notes: notes.value,
      userId: 2,
      bought: false,
      currency: currency.value
    };

    const response = await axios.put(`https://localhost:32769/api/wish/${wishId}`, updatedWish);
    console.log('Wish updated:', response.data);
    alert('Wish updated successfully!');
  } catch (error) {
    console.error('Error updating wish:', error);
    alert('Failed to update wish. Please try again.');
  }
};

const deleteWish = async () => {
  try {
    const response = await axios.delete(`https://localhost:32769/api/wish/${wishId}`);
    console.log('Wish deleted:', response.data);
    alert('Wish deleted successfully!');
    router.push('/');
  } catch (error) {
    console.error('Error deleting wish:', error);
    alert('Failed to delete wish. Please try again.');
  }
};

onMounted(() => {
  getWishDetails();
});
</script>
