<template>
  <v-btn :color="props.color" :elevation="12" :flat="true" class="my-button">
    <div class="letter">{{ props.char }}</div>
  </v-btn>
</template>

<script setup lang="ts">
export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})
</script>

<style scoped>
.my-button {
  width: 100px;
  min-width: 100px;
  height: 100px;
  min-height: 100px;
  background-image: linear-gradient(to right, #00000040, #ffffff40) !important;
}

.letter {
  font-size: 85px;
  color: white;
}
</style>
