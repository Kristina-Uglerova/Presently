<script setup>
import { useRouter } from 'vue-router';
import {onMounted, ref} from "vue";
import axios from "axios";
const router = useRouter();
const userId = 2;
const goToCreateWishForm = () => {
  router.push('createWish');
};

const wishes = ref([]);
const getUserWishes = async () => {
  try {
    const response = await axios.get(`https://localhost:32769/api/wish/user/${userId}`);
    wishes.value = response.data;
  } catch (error) {
    console.error('Error fetching user wishes:', error);
    alert('Failed to load wishes. Please try again.');
  }
};

const goToEditWishForm = (wishId) => {
  router.push({ name: 'editWish', params: { id: wishId } });
};

onMounted(() => {
  getUserWishes();
});
</script>

<template>
  <table class="table table-striped">
    <thead>
    <tr>
      <th>Name</th>
      <th>Notes</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="wish in wishes" :key="wish.id" @click="goToEditWishForm(wish.id)" style="cursor: pointer;">
      <td>{{ wish.name }}</td>
      <td>{{ wish.notes }}</td>
    </tr>
    </tbody>
  </table>
  <button class="fab" @click="goToCreateWishForm">
    <i>+</i>
  </button>
</template>

<style scoped>

</style>