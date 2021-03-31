export interface ApiResponse <TData>{
  data: TData;
  successMessage: string;
  errorMessages: string[];
}
