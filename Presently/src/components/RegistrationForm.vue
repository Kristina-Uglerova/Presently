<template>
  <div class="container d-flex justify-content-center align-items-center min-vh-100">
    <div class="register-form card p-4 shadow-sm" style="max-width: 500px; width: 100%;">
      <form @submit.prevent="handleSubmit">
        <h2 class="mb-4 text-center">Create a Profile</h2>
        <div class="mb-3">
          <input
              type="text"
              v-model="username"
              class="form-control"
              placeholder="Username"
              required
          />
        </div>

        <div class="mb-3">
          <input
              type="email"
              v-model="email"
              class="form-control"
              placeholder="Email"
              required
          />
        </div>

        <div class="mb-3">
          <input
              type="date"
              v-model="birthday"
              class="form-control"
              required
          />
        </div>

        <div class="mb-3">
          <input
              type="password"
              v-model="password"
              class="form-control"
              placeholder="Password"
              required
          />
        </div>

        <div class="mb-3">
          <input
              type="password"
              v-model="confirmPassword"
              class="form-control"
              placeholder="Confirm Password"
              required
          />
        </div>

        <button type="submit" class="pill_button w-100">Confirm</button>
      </form>
    </div>
    <div class="wave_container"></div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import axios from 'axios';

const username = ref('');
const email = ref('');
const birthday = ref('');
const password = ref('');
const confirmPassword = ref('');

const handleSubmit = async () => {
  if (password.value !== confirmPassword.value) {
    alert('Passwords do not match!');
    return;
  } else if (!password.value || !confirmPassword.value || !email.value || !birthday.value || !username.value) {
    alert('Please fill all required fields');
    return;
  }

  try {
    const response = await axios.post('https://localhost:32769/api/user', {
      username: username.value,
      email: email.value,
      birthday: birthday.value,
      password: password.value,
    });

    console.log('Registration successful:', response.data);
    alert('User registered successfully!');
  } catch (error) {
    console.error('Registration failed:', error.response?.data || error.message);
    alert('Failed to register user. Please try again.');
  }
};
</script>

<style scoped>
.register-form {
  background-color: #fff;
  border-radius: 8px;
}
</style>
