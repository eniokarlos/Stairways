import { useGridAlignment } from './gridAlignment';

const gridStore = useGridAlignment();

export function alignToGrid(value: number, gridSize: number = 8): number {
  if (gridStore.state.value) {
    return Math.round((value) / gridSize) * gridSize;
  }

  return value;
}