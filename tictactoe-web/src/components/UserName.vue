<template>
  <v-dialog v-model="user1" width="300" persistent>
    <template v-slot:activator="{ props }">
      <v-btn class="player1-box" v-bind="props" color="secondary">
        <strong>{{ player1 }}</strong>
      </v-btn>
    </template>

    <v-card>
      <v-card-text>
        <v-text-field v-model="player1" label="Username for Player 1"></v-text-field>
      </v-card-text>
      <v-card-actions class="d-flex justify-center">
        <v-btn @click="setplayer1" color="primary">Confirm</v-btn>
        <v-btn @click="user1 = false" color="error">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <v-dialog v-model="user2" width="300" persistent :disabled="multi">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" class="player2-box" color="secondary">
        <strong>{{ player2 }}</strong>
      </v-btn>
    </template>

    <v-card>
      <v-card-text>
        <v-text-field v-model="player2" label="Username for Player 2"></v-text-field>
      </v-card-text>
      <v-card-actions class="d-flex justify-center">
        <v-btn @click="setplayer2" color="primary">Confirm</v-btn>
        <v-btn @click="user2 = false" color="error">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'


const user1 = ref(false)
const user2 = ref(false)
const player1 = ref('Player 1')
const player2 = ref('Player 2')
const multi = ref(true)
const route = useRoute()
const pat = ref<string>(route.path)

onMounted(() => {
  const multi = ref(true)
  if (localStorage.getItem('player1') != null) {
    player1.value = localStorage.getItem('player1')!
  } else if (localStorage.getItem('player1') === null) {
    localStorage.setItem('player1', 'Player 1')
  }

  if (pat.value === '/Hardbot') {
    localStorage.setItem('player2', 'Hard bot')
    player2.value = "Hard bot"
    multi.value = false
  } else if (pat.value === '/Easybot') {
    localStorage.setItem('player2', 'Easy bot')
    player2.value = "Easy bot"
    multi.value = false
  } else if (localStorage.getItem('player2') != null) {
    player2.value = localStorage.getItem('player2')!
  } else if (localStorage.getItem('player2') === null) {
    localStorage.setItem('player2', 'Player 2')
  }
})

function setplayer1() {
  user1.value = false
  localStorage.setItem('player1', player1.value)
}

function setplayer2() {
  user2.value = false
  localStorage.setItem('player2', player2.value)
}
</script>

<style scoped>
.player1-box {
  float: left;
}

.player2-box {
  float: right;
}
</style>
