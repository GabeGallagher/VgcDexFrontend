import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'countryFlag',
})
export class CountryFlagPipe implements PipeTransform {
  transform(countryCode: string): string {
    return `https://flagcdn.com/w20/${countryCode}.png`;
  }
}
