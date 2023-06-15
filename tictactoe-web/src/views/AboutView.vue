<template>
  <v-sheet>
    <v-card>
      <v-card-title>About</v-card-title>
      <p>
        Tic-tac-toe is a classic paper-and-pencil game played on a 3x3 grid. Two players take turns placing their X or O symbols on empty cells with the goal of creating a line of three symbols horizontally, vertically, or diagonally. The game is won by the player who successfully forms a line of three, while a tie occurs if all cells are filled without a winner. Although Tic-tac-toe is a solved game, where optimal play leads to a draw, it remains a popular and accessible game that promotes logical thinking and strategy development.
      </p>
      <v-btn @click="$router.back()">Back</v-btn>
    </v-card>
  </v-sheet>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
