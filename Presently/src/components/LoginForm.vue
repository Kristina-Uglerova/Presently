<template>
  <div class="container d-flex justify-content-center align-items-center min-vh-100">
    <div class="register-form card p-4 shadow-sm" style="max-width: 500px; width: 100%;">
      <form>
        <h2 class="mb-4 text-center">Log in</h2>
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
              type="password"
              v-model="password"
              class="form-control"
              placeholder="Password"
              required
          />
        </div>

        <button type="submit" class="pill_button w-100">Submit</button>
      </form>
    </div>
    <div class="wave_container"></div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

const email = ref('');
const password = ref('');

</script>

<style scoped>
.register-form {
  background-color: #fff;
  border-radius: 8px;
}
</style>
