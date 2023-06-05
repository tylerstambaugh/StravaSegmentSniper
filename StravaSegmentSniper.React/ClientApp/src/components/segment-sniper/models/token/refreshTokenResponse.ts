// {
//     "token_type": "Bearer",
//     "access_token": "10c8b79eb48de66e180c79b84116e226d8aa90ec",
//     "expires_at": 1685943320,
//     "expires_in": 18768,
//     "refresh_token": "fb788d5771069026032798f7f7928756b28da256"
// }
export interface RefreshTokenResponse {
  token_type: string;
  access_token: string;
  expires_at: number;
  expires_in: number;
  refresh_token: number;
}
