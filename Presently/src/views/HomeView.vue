<template>
  <div>
    <nav class="navbar">
      <ul>
        <li><RouterLink to="/">Home</RouterLink></li>
        <li><RouterLink to="/profile">Profile</RouterLink></li>
        <li><RouterLink to="/calendar">Calendar</RouterLink></li>
        <li><RouterLink to="/wishes">Wishes</RouterLink></li>
      </ul>
    </nav>

    <div class="header">
      <div class="text">
        <span class="main_title">Presently</span>
        <span class="subtitle">make a wish</span>
        <button class="pill_button" @click="goToLogin">Log in</button>
        <button class="pill_button" @click="goToRegister">Create profile</button>
      </div>
      <img src="../assets/logo.png" alt="Logo" class="logo" />
    </div>

    <div class="wave_container"></div>

    <div class="about_us">
      <span class="subtitle">About us</span>
      <span class="text">
        <br />
        Welcome to Presently, the ultimate platform for creating and sharing wishlists!
        <br /><br />
        We believe in the joy of giving and the excitement of receiving the perfect gift. Our mission is to make it easier for you to let your friends and family know exactly what you’re wishing for, and to help them make your special moments even more memorable.
        <br /><br />
        At Presently, we value connection, thoughtfulness, and simplicity. Whether it's for a birthday, holiday, or any celebration, we provide a space where you can create, manage, and share your wishlist with the people who matter most. And for those browsing your list, they can mark gifts as purchased, ensuring no more duplicate presents while keeping the surprise alive for you!
        <br /><br />
        Join Presently today and let’s make gifting more personal, thoughtful, and fun!
      </span>
    </div>
  </div>
</template>

<script setup>
import { useRouter } from 'vue-router';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

const router = useRouter();

const goToLogin = () => {
  router.push('/login');
};

const goToRegister = () => {
  router.push('/register');
};


</script>

<style scoped>
</style>