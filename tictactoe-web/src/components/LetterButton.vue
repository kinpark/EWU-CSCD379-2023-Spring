<template>
  <LetterBase :char="localChar" :color="props.letter.color" @click="updateChar"></LetterBase>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter'
import LetterBase from './LetterBase.vue'
import { ref, computed } from 'vue'

export interface Props {
  letter: Letter
}

const props = defineProps<Props>()
const updatedChar = ref('X')

const localChar = computed({
  get: () => props.letter.char,
  set: (value) => {
    updatedChar.value = value
  }
})

function updateChar() {
  localChar.value = updatedChar.value === 'X' ? 'O' : 'X'
}
</script>
