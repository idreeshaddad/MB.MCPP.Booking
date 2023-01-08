import { UploaderMode } from './uploaderMode.enum';

export class ImageUploaderConfig {
  
  mode: UploaderMode;
  multiple: boolean;

  constructor(mode: UploaderMode, multiple: boolean = false) {
    this.mode = mode;
    this.multiple = multiple;
  }
}
