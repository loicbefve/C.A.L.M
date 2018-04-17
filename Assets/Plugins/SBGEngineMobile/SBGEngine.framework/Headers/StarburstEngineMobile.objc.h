// Objective-C API for talking to github.com/StarburstComputing/engine-go/mobile Go package.
//   gobind -lang=objc -prefix="StarburstEngine" github.com/StarburstComputing/engine-go/mobile
//
// File is generated by gobind. Do not edit.

#ifndef __StarburstEngineMobile_H__
#define __StarburstEngineMobile_H__

@import Foundation;
#include "Universe.objc.h"


// skipped const DefaultDiscoveryScanInterval with unsupported type: *types.Const

/**
 * DefaultGRPCBindingAddress represents the default gRPC binding address
 */
FOUNDATION_EXPORT NSString* const StarburstEngineMobileDefaultGRPCBindingAddress;
// skipped const DefaultGRPCKeepaliveTime with unsupported type: *types.Const

// skipped const DefaultGRPCKeepaliveTimeout with unsupported type: *types.Const

/**
 * DefaultGRPCPort represents the default gRPC port
 */
FOUNDATION_EXPORT const int64_t StarburstEngineMobileDefaultGRPCPort;
// skipped const DefaultLogFileMaxAge with unsupported type: *types.Const

// skipped const DefaultLogFileRotationTime with unsupported type: *types.Const


/**
 * Start Starburst Engine
 */
FOUNDATION_EXPORT BOOL StarburstEngineMobileStart(NSError** error);

/**
 * Stop Starburst Engine
 */
FOUNDATION_EXPORT void StarburstEngineMobileStop(void);

#endif
