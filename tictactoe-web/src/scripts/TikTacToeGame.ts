export class TikTacToeGame {
  static readonly #winningCombinations = [
    ['a1', 'a2', 'a3'],
    ['b1', 'b2', 'b3'],
    ['c1', 'c2', 'c3'],
    ['a1', 'b1', 'c1'],
    ['a2', 'b2', 'c2'],
    ['a3', 'b3', 'c3'],
    ['a1', 'b2', 'c3'],
    ['a3', 'b2', 'c1']
  ]

  static readonly #possibewinmove = [
    ['a1', 'a2'], //0
    ['b1', 'b2'], //1
    ['c1', 'c2'], //2
    ['a2', 'a3'], //3
    ['b2', 'b3'], //4
    ['c2', 'c3'], //5
    ['a1', 'b1'], //6
    ['a2', 'b2'], //7
    ['a3', 'b3'], //8
    ['b1', 'c1'], //9
    ['b2', 'c2'], //10
    ['b3', 'c3'], //11
    ['a1', 'b2'], //12
    ['a3', 'b2'], //13
    ['c1', 'b2'], //14
    ['c3', 'b2'] //15
  ]

  static readonly #answermove = [
    ['a3'], //0
    ['b3'], //1
    ['c3'], //2
    ['a1'], //3
    ['b1'], //4
    ['c1'], //5
    ['c1'], //6
    ['c2'], //7
    ['c3'], //8
    ['a1'], //9
    ['a2'], //10
    ['a3'], //11
    ['c3'], //12
    ['c1'], //13
    ['a3'], //14
    ['a1'] //15
  ]

  getAnswerMove(player1Moves: string[], player2Moves: string[]): string {
    const allMoves = player1Moves.concat(player2Moves);
  
    for (let i = 0; i < TikTacToeGame.#possibewinmove.length; i++) {
      const [move1, move2] = TikTacToeGame.#possibewinmove[i];
  
      if (player1Moves.includes(move1) && !player2Moves.includes(TikTacToeGame.#answermove[i][0])) {
        return TikTacToeGame.#answermove[i][0];
      }
    }
  
    // If no available answer move is found, return 'No move'
    return 'No move';
  }



  checkForWinner(player1Moves: string[], player2Moves: string[]) {
    for (const winningCombination of TikTacToeGame.#winningCombinations) {
      const player1HasWinningCombination = winningCombination.every((move) =>
        player1Moves.includes(move)
      )
      const player2HasWinningCombination = winningCombination.every((move) =>
        player2Moves.includes(move)
      )
      if (player1HasWinningCombination) {
        return 'X player wins!'
      } else if (player2HasWinningCombination) {
        return 'O player wins!'
      }
    }
    return 0
  }

  winComb(player1Moves: string[], player2Moves: string[]) {
    for (const winningCombination of TikTacToeGame.#winningCombinations) {
      const player1HasWinningCombination = winningCombination.every((move) =>
        player1Moves.includes(move)
      )
      const player2HasWinningCombination = winningCombination.every((move) =>
        player2Moves.includes(move)
      )
      if (player1HasWinningCombination) {
        return winningCombination
      } else if (player2HasWinningCombination) {
        return winningCombination
      }
    }
  }
}
