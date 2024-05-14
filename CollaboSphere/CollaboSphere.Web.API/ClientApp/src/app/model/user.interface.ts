export interface User {
  userId: number;
  username: string;
  email: string;
  firstName?: string; // The '?' makes this property optional
  lastName?: string;  // Optional
  roleId?: number;    // Optional
  lastLogin?: Date;   // Optional, using Date for DateTime
  isActive?: boolean; // Optional
}
