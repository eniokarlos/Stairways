import { Directive } from 'vue';

export const vRoundDecimals: Directive<HTMLInputElement> = (el: HTMLInputElement) => {
  el.valueAsNumber = Math.round(el.valueAsNumber * 100) / 100;
};