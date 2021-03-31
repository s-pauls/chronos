export interface ApiResponse <TData>{
  data: TData;
  errorMessages: string[];
}
