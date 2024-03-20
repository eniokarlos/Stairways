export function alignToGrid(value: number, gridSize: number = 8): number {
  return Math.round((value) / gridSize) * gridSize;
}