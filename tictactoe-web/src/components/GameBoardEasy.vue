<template>
  <v-row class="justify-center">
    <v-col cols="auto">
      <h1><Strong>Tic Tac Toe against <v-icon icon="mdi-baby-face"></v-icon> EASY bot</Strong></h1>
    </v-col>
  </v-row>

  <div>
    <v-row class="justify-center" dense v-for="(row, rowIndex) in grid" :key="rowIndex">
      <v-col cols="auto" dense v-for="(letter, columnIndex) in row" :key="columnIndex">
        <LetterBase
          :char="letter.char"
          :color="letter.color"
          @click="updateChar(rowIndex, columnIndex)"
          :disabled="letter.clicked"
        ></LetterBase>
      </v-col>
    </v-row>
  </div>

  <UserName class="boardfix" />

  <br />
  <br />

  <v-row class="justify-center">
    <v-col cols="auto">
      <v-btn @click="restartGame" color="primary">Restart game</v-btn>
    </v-col>
  </v-row>

  <div class="text-h4 text-center mt-10" v-if="win=== 'X player wins!'">Player win!</div>
    <div class="text-h4 text-center mt-10" v-if="win=== 'O player wins!'"><v-icon icon="mdi-baby-carriage"></v-icon> Bot win! <v-icon icon="mdi-baby-carriage"></v-icon></div>
</template>

<script setup lang="ts">
import LetterBase from './LetterBase.vue'
import { ref } from 'vue'
import { TikTacToeGame } from '../scripts/TikTacToeGame'
import UserName from './UserName.vue'
import Axios from 'axios'

const win = ref<string | null>(null)

interface Letter {
  char: string
  color: string
  clicked: boolean
}

const props = defineProps<{
  grid: Letter[][]
}>()

const game = new TikTacToeGame()
const player1Moves = ref<string[]>([])
const player2Moves = ref<string[]>([])
let currentPlayer = 'player1'
const grid = ref([...props.grid])
const movecount = ref(0)

function updateChar(rowIndex: number, columnIndex: number) {
  const position = getPosition(rowIndex, columnIndex)
  if (win.value || props.grid[rowIndex][columnIndex].clicked) {
    return
  }
  if (currentPlayer === 'player1') {
    grid.value[rowIndex][columnIndex].char = 'X'
    grid.value[rowIndex][columnIndex].clicked = true
    movecount.value++
    player1Moves.value.push(position)
    currentPlayer = 'player2'
    checkForWinner()
    if (!win.value && movecount.value < 9) {
      makeComputerMove()
    }
  }
}

function makeComputerMove() {
  const emptyBoxes: { rowIndex: number; columnIndex: number }[] = []
  grid.value.forEach((row, rowIndex) => {
    row.forEach((letter, columnIndex) => {
      if (!letter.clicked) {
        emptyBoxes.push({ rowIndex, columnIndex })
      }
    })
  })

  if (emptyBoxes.length > 0) {
    const randomIndex = Math.floor(Math.random() * emptyBoxes.length)
    const { rowIndex, columnIndex } = emptyBoxes[randomIndex]
    grid.value[rowIndex][columnIndex].char = 'O'
    grid.value[rowIndex][columnIndex].clicked = true
    movecount.value++
    player2Moves.value.push(getPosition(rowIndex, columnIndex))
    currentPlayer = 'player1'

    checkForWinner()
  }
}

function getPosition(rowIndex: number, columnIndex: number): string {
  const letters = ['a', 'b', 'c']
  const numbers = ['1', '2', '3']
  console.log(`${letters[rowIndex]}${numbers[columnIndex]}`)
  return `${letters[rowIndex]}${numbers[columnIndex]}`
}

function restartGame() {
  player1Moves.value = []
  player2Moves.value = []
  win.value = null
  movecount.value = 0
  currentPlayer = 'player1'
  grid.value.forEach((row) => {
    row.forEach((letter) => {
      letter.char = ''
      letter.color = ''
      letter.clicked = false
    })
  })
}

function checkForWinner() {
  const winner = game.checkForWinner(player1Moves.value, player2Moves.value)
  if (winner) {
    win.value = winner
    console.log(winner)
    const winningCombination = game.winComb(player1Moves.value, player2Moves.value)
    highlightWinningCombination(winningCombination as string[])
    postresult()
  } else if (movecount.value === 9) {
    win.value = "It's a draw"
    postresult()
  }
}

function highlightWinningCombination(winningCombination: string[]): void {
  winningCombination.forEach((position) => {
    const rowIndex = position.charCodeAt(0) - 97
    const columnIndex = parseInt(position[1]) - 1
    grid.value[rowIndex][columnIndex].color = 'correct'
  })
}

function postresult() {
  Axios.post(
    `Player/AddPlayer?newName=${localStorage.getItem('player1')}&WonGame=${
      win.value === 'X player wins!' ? true : false
    }`
  )
    .then((response): void => {
      console.log(response.data)
    })
    .catch((error) => {
      console.log(error)
    })
}
</script>

<style scoped>
.boardfix {
  position: fixed;
}
</style>
