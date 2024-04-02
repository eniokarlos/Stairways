const state = { value: true };
export function useGridAlignment() {

  function toggle() {
    state.value = !state.value;
    return state;
  }
  
  return {
    state,
    toggle, 
  };
}