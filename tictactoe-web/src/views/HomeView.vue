<template>
  <v-container class="text-center">
    <h1><strong>Welcome to Tic Tac Toe</strong></h1>
    <br/>
    <h3>A game a casual game of Tic Tac Toe against your friend</h3>
    <v-btn @click="$router.push('/TikTacToe')" color="primary">Tic Tac Toe </v-btn>
    <br/>
    <br/>
    <h3>A game a casual game of Tic Tac Toe against an easy bot</h3>
    <v-btn @click="$router.push('/Easybot')" color="primary">Against Bot</v-btn>
    <br/>
    <br/>
    <h3>Check out how you stack up against other players</h3>
    <v-btn @click="$router.push('/Leaderboard')" color="primary">Leaderboard</v-btn>
    <br/>
    <br/>
    <h3>Learn more about us</h3>
    <v-btn @click="$router.push('/about')" color="primary">About</v-btn>
    <br/>
    <br/>


  </v-container>
</template>

<script setup lang="ts">
</script>


