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
    
    checkForWinner(player1Moves : string[], player2Moves : string[])  {
        for (const winningCombination of TikTacToeGame.#winningCombinations) {
            const player1HasWinningCombination = winningCombination.every((move) => player1Moves.includes(move))
            const player2HasWinningCombination = winningCombination.every((move) => player2Moves.includes(move))
            if (player1HasWinningCombination) {
            return 'X player wins!'
            } else if (player2HasWinningCombination) {
            return 'O player wins!'
            }
        }
        return 0
    }

    winComb(player1Moves : string[], player2Moves : string[]) {
        for (const winningCombination of TikTacToeGame.#winningCombinations) {
            const player1HasWinningCombination = winningCombination.every((move) => player1Moves.includes(move))
            const player2HasWinningCombination = winningCombination.every((move) => player2Moves.includes(move))
            if (player1HasWinningCombination) {
            return winningCombination
            } else if (player2HasWinningCombination) {
            return winningCombination
            }
        }
    }
  
    
  }
  