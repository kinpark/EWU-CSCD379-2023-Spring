<template>
    <v-row class="justify-center">
      <v-col cols="auto">
        <h1><strong>Tic Tac Toe against <v-icon icon="mdi-skull"></v-icon> HARD bot</strong></h1>     
    </v-col>
    </v-row>

    <img class="shrug" :src="shrug" alt="Sans shrug GIF">
    <img class="sans" :src="sans" alt="Sans GIF">
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
    <div class="text-h4 text-center mt-10" v-if="win && movecount == 9">{{ win }}</div>
    <div class="text-h4 text-center mt-10" v-if="win=== 'O player wins!'"><v-icon icon="mdi-emoticon-devil"></v-icon> Bot win! <v-icon icon="mdi-emoticon-devil"></v-icon></div>

    
  </template>
  <script setup lang="ts">
  import LetterBase from './LetterBase.vue'
  import { ref, onMounted, onBeforeUnmount } from 'vue';
  import { TikTacToeGame } from '../scripts/TikTacToeGame'
  import UserName from './UserName.vue'
  import Axios from 'axios'
    import clicking_button from '@/assets/clicking_button_sound.mp3'
    import megalovinia from '@/assets/megalovania.mp3'
    import sans from '@/assets/sans.gif'
    import shrug from '@/assets/sans-shrug.gif'
  
  const win = ref<string | null>(null)
  
  interface Letter {
    char: string
    color: string
    clicked: boolean
  }
  
  
  onMounted(() => {
      makeComputerMove()
      megaloviniasound.play()
      megaloviniasound.volume = 0.4
  })
  onBeforeUnmount(() => {
    megaloviniasound.pause()
  })

  const props = defineProps<{
    grid: Letter[][]
  }>()

  
  const game = new TikTacToeGame()
  const player1Moves = ref<string[]>([])
  const player2Moves = ref<string[]>([])
  let currentPlayer = 'player1'
  const grid = ref([...props.grid])
  const movecount = ref(0)
  const clicksound = new Audio(clicking_button)
    const megaloviniasound = new Audio(megalovinia)
  
  function updateChar(rowIndex: number, columnIndex: number) {
    const position = getPosition(rowIndex, columnIndex)
    if (win.value || props.grid[rowIndex][columnIndex].clicked) {
      return
    }
    if (currentPlayer === 'player1') {
        clicksound.play()
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
  
  function getPositionCoordinates(position: string): { rowIndex: number; columnIndex: number } {
  const letters = ['a', 'b', 'c'];
  const numbers = ['1', '2', '3'];
  const rowIndex = letters.indexOf(position[0]);
  const columnIndex = numbers.indexOf(position[1]);
  return { rowIndex, columnIndex };
}

  function makeComputerMove() {
  if (win.value || movecount.value === 9) {
    return;
  }
  let answermove = game.getAnswerMove(player1Moves.value, player2Moves.value);
  
  if (answermove != 'No move') {
    console.log("HERE THE MOVE KID "+answermove);
    const { rowIndex, columnIndex } = getPositionCoordinates(answermove);
    answermove = 'No move';
    
    grid.value[rowIndex][columnIndex].char = 'O';
    grid.value[rowIndex][columnIndex].clicked = true;
    movecount.value++;
    player2Moves.value.push(getPosition(rowIndex, columnIndex));
    currentPlayer = 'player1';

    checkForWinner();
  } else {
  


  const bestMove = getBestMove(grid.value, player1Moves.value, player2Moves.value, currentPlayer);
  const { rowIndex, columnIndex } = bestMove;

  grid.value[rowIndex][columnIndex].char = 'O';
  grid.value[rowIndex][columnIndex].clicked = true;
  movecount.value++;
  player2Moves.value.push(getPosition(rowIndex, columnIndex));
  currentPlayer = 'player1';

  checkForWinner();
  }
}
  
  function getAvailableMoves(currentGrid: Letter[][]): { rowIndex: number; columnIndex: number }[] {
    const availableMoves: { rowIndex: number; columnIndex: number }[] = [];
  
    currentGrid.forEach((row, rowIndex) => {
      row.forEach((letter, columnIndex) => {
        if (!letter.clicked) {
          availableMoves.push({ rowIndex, columnIndex });
        }
      });
    });
  
    return availableMoves;
  }
  
  function getBestMove(currentGrid: Letter[][], player1Moves: string[], player2Moves: string[], currentPlayer: string): { rowIndex: number; columnIndex: number } {
  const availableMoves: { rowIndex: number; columnIndex: number }[] = getAvailableMoves(currentGrid);
  let bestScore = -Infinity;
  let bestMove: { rowIndex: number; columnIndex: number } | undefined = undefined;

  for (const move of availableMoves) {
    const { rowIndex, columnIndex } = move;
    const newGrid: Letter[][] = JSON.parse(JSON.stringify(currentGrid));
    newGrid[rowIndex][columnIndex].char = 'O';
    newGrid[rowIndex][columnIndex].clicked = true;
    const newPlayer2Moves = [...player2Moves, getPosition(rowIndex, columnIndex)];
    currentPlayer = 'player1';

    const score = minimax(newGrid, player1Moves, newPlayer2Moves, currentPlayer, true, -Infinity, Infinity);
    if (score > bestScore) {
      bestScore = score;
      bestMove = move;
    }
  }

  if (!bestMove) {
    bestMove = availableMoves[Math.floor(Math.random() * availableMoves.length)];
  }


  return bestMove;
}

  
  function minimax(currentGrid: Letter[][], player1Moves: string[], player2Moves: string[], currentPlayer: string, isMaximizingPlayer: boolean, alpha: number, beta: number): number {
    const winner = game.checkForWinner(player1Moves, player2Moves);
    if (winner) {
      if (winner === 'X player wins!') {
        return -1;
      } else {
        return 1;
      }
    } else if (movecount.value === 9) {
      return 0;
    }
  
    if (isMaximizingPlayer) {
      let bestScore = -Infinity;
      const availableMoves = getAvailableMoves(currentGrid);
  
      for (const move of availableMoves) {
        const { rowIndex, columnIndex } = move;
        const newGrid: Letter[][] = JSON.parse(JSON.stringify(currentGrid));
        newGrid[rowIndex][columnIndex].char = 'O';
        newGrid[rowIndex][columnIndex].clicked = true;
        const newPlayer2Moves = [...player2Moves, getPosition(rowIndex, columnIndex)];
        currentPlayer = 'player1';
  
        const score = minimax(newGrid, player1Moves, newPlayer2Moves, currentPlayer, true, alpha, beta);
        bestScore = Math.max(score, bestScore);
        alpha = Math.max(alpha, bestScore);
  
        if (beta <= alpha) {
          break;
        }
      }
  
      return bestScore;
    } else {
      let bestScore = Infinity;
      const availableMoves = getAvailableMoves(currentGrid);
  
      for (const move of availableMoves) {
        const { rowIndex, columnIndex } = move;
        const newGrid: Letter[][] = JSON.parse(JSON.stringify(currentGrid));
        newGrid[rowIndex][columnIndex].char = 'X';
        newGrid[rowIndex][columnIndex].clicked = true;
        const newPlayer1Moves = [...player1Moves, getPosition(rowIndex, columnIndex)];
        currentPlayer = 'player2';
  
        const score = minimax(newGrid, newPlayer1Moves, player2Moves, currentPlayer, true, alpha, beta);
        bestScore = Math.min(score, bestScore);
        beta = Math.min(beta, bestScore);
  
        if (beta <= alpha) {
          break;
        }
      }
  
      return bestScore;
    }
  }
  
  function getPosition(rowIndex: number, columnIndex: number): string {
    const letters = ['a', 'b', 'c']
    const numbers = ['1', '2', '3']
    return `${letters[rowIndex]}${numbers[columnIndex]}`
  }
  
  function restartGame() {
    clicksound.play()
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
    makeComputerMove()
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
      Axios.post(
      `Player/AddPlayer?newName=Hardbot&WonGame=${
        win.value === 'O player wins!' ? true : false
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
     .shrug {
       position: absolute;
       width: 200px;
       height: 200px;
       left: 80%;
     }
     .sans {
       position: absolute;
       right: 80%;
     }
 
 
    .boardfix {
      position: fixed;
    }
    </style>
  