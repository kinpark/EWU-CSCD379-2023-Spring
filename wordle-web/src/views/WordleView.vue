<template>
  <h1>Wordle Mind Bender</h1>
  <<<<<<< HEAD

  <GameBoard :game="game" @letterClick="addChar" />

  ======= >>>>>>> main
  <v-text-field
    v-model="guess"
    label="Guess"
    variant="solo"
    @keydown.prevent="($event:KeyboardEvent) => keyPress($event)"
  ></v-text-field>

  <<<<<<< HEAD
  <KeyBoard @letterClick="addChar" />

  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>
  =======
  <v-btn @click="checkGuess" @keyup.enter="checkGuess"> Check </v-btn>
  <div>
    <v-row v-for="word in game.guesses" :key="word.text">
      <v-col v-for="letter in word.letters" :key="letter.char">
        <LetterButton :letter="letter" @click="letterClick(letter, $event)"></LetterButton>
      </v-col>
    </v-row>
  </div>
  >>>>>>> main

  <h2>{{ guess }}</h2>
  <h3>{{ game.secretWord }}</h3>
</template>

<script setup lang="ts">
import { WordleGame } from '@/scripts/wordleGame'
import { ref, reactive } from 'vue'
<<<<<<< HEAD
import GameBoard from '../components/GameBoard.vue'
import KeyBoard from '../components/KeyBoard.vue'
=======
import LetterButton from '../components/LetterButton.vue'
>>>>>>> main
import type { Letter } from '@/scripts/letter'
import { watch, onMounted, onUnmounted } from 'vue'

const guess = ref('')
const game = reactive(new WordleGame())
console.log(game.secretWord)

onMounted(() => {
  window.addEventListener('keyup', keyPress)
})
onUnmounted(() => {
  window.removeEventListener('keyup', keyPress)
})

watch(
  guess,
  (newGuess, oldGuess) => {
    if (newGuess.length > 5) {
      guess.value = oldGuess || ''
    }
  },
  { flush: 'post' }
)

function checkGuess() {
  game.submitGuess()
  guess.value = ''
}

<<<<<<< HEAD
function addChar(letter: Letter) {
  game.guess.push(letter.char)
  guess.value += letter.char
=======
function letterClick(letter: Letter, event: MouseEvent) {
  guess.value += letter.char
  console.log(event.altKey)
>>>>>>> main
}

function keyPress(event: KeyboardEvent) {
  console.log(event.key)
  if (event.key === 'Enter') {
    checkGuess()
  } else if (event.key === 'Backspace') {
    guess.value = guess.value.slice(0, -1)
    game.guess.pop()
    console.log('Back')
  } else if (event.key.length === 1 && event.key !== ' ') {
    guess.value += event.key.toLowerCase()
    game.guess.push(event.key.toLowerCase())
  }
  //event.preventDefault()
}
</script>
