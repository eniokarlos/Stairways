import { sha1 } from 'js-sha1';
import { ItemContent } from '../RmItem.vue';

export default function getItemContentHash(content: ItemContent) {
  const data =  `
    ${content?.title};
    ${content?.description};
    ${content?.links.map(l => `${l.text};${l.url}`)};
  `;

  return sha1(data);
} 