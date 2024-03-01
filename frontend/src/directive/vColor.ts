import { Directive, DirectiveBinding } from "vue";

export const vColor: Directive<HTMLElement, string> = (el: HTMLElement, binding: DirectiveBinding<string>) => {
  const varName = '--current-color';

  el.style.setProperty(varName, `var(--${binding.value})`)
};