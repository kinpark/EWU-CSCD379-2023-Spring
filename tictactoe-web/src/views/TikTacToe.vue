<template>
  <GameBoard :grid="grid" />
</template>

<script setup lang="ts">
import { ref } from 'vue'
import GameBoard from '@/components/GameBoard.vue'

const current = ref('X')
const grid = ref([
  [
    { char: '', color: '', clicked: false },
    { char: '', color: '', clicked: false },
    { char: '', color: '', clicked: false }
  ],
  [
    { char: '', color: '', clicked: false },
    { char: '', color: '', clicked: false },
    { char: '', color: '', clicked: false }
  ],
  [
    { char: '', color: '', clicked: false },
    { char: '', color: '', clicked: false },
    { char: '', color: '', clicked: false }
  ]
])
</script>
