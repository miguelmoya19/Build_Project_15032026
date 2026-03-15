import { trigger, transition, style, animate, keyframes } from '@angular/animations';

export const fadeInAnimation = trigger('routeAnimations', [
  transition('* <=> *', [
    animate('500ms ease-in-out', keyframes([
      style({ opacity: 0, transform: 'scale(0.9) translateY(20px)', offset: 0 }),
      style({ opacity: 0.5, transform: 'scale(0.95) translateY(10px)', offset: 0.5 }),
      style({ opacity: 1, transform: 'scale(1) translateY(0)', offset: 1 })
    ]))
  ])
]);