<template>
  <v-sheet color="blue" height="170px" class="pt-10 my-5">
    <v-card color="indigo-darken-3" class="ma-5" elevation="5" rounded="xl">
      <v-card-title>Hello World</v-card-title>
    </v-card>
  </v-sheet>

  <WeatherDialog v-model="isDialogOpen"></WeatherDialog>
  {{ isDialogOpen }}
  <v-card v-for="item in weatherData" :key="item.data">
    {{ item.data }} - {{ item.temperatureC }} - {{ item.temperatureF }} - {{ item.summary }}
  </v-card>
</template>

<script setup lang="ts">
import Axios from "axios";
import { ref } from "vue";
import WeatherDialog from "@/components/WeatherDialog.vue";

interface weatherData {
  date: string
  temperatureC: number
  temperatureF: number
  summary: string
}

const isDialogOpen = ref(false)
const weatherData = ref<weatherData>()

Axios.get('https://localhost:7225/WeatherForecast')
  .then(response) => {
    console.log(response.data)
    weatherData.value = response.data
  })
  .catch(err) => {
    console.log(err)
  })

</script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
