import { useRoadmapStore } from '@/stores/roadmap.store';

const store = useRoadmapStore();

export function alignToGrid(value: number, gridSize: number = 8): number {
  if (store.gridAlignment) {
    return Math.round((value) / gridSize) * gridSize;
  }

  return value;
}